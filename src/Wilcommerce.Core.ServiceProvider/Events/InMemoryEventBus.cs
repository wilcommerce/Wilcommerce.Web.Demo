using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Wilcommerce.Core.Infrastructure;

namespace Wilcommerce.Core.ServiceProvider.Events
{
    public class InMemoryEventBus : IEventBus
    {
        private readonly IServiceCollection _services;

        private IDictionary<Type, IList<Type>> _handlersMapping;

        public InMemoryEventBus(IServiceCollection services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
            _handlersMapping = new Dictionary<Type, IList<Type>>();
        }

        public void RaiseEvent<TEvent>(TEvent @event) where TEvent : DomainEvent
        {
            if (@event is null)
            {
                throw new ArgumentNullException(nameof(@event));
            }

            try
            {
                var handlers = LoadHandlersForEvent(@event);
                if (handlers.Any())
                {
                    foreach (var handler in handlers)
                    {
                        dynamic handlerInstance = _services.BuildServiceProvider().GetService(handler);
                        handlerInstance.Handle((dynamic)@event);
                    }
                }
            }
            catch 
            {
            }
        }

        public void RegisterHandler<TEvent, THandler>()
            where TEvent : DomainEvent
            where THandler : IHandleEvent<TEvent>
        {
            var eventType = typeof(TEvent);
            var handlerType = typeof(THandler);

            if (!_handlersMapping.ContainsKey(eventType))
            {
                _handlersMapping.Add(eventType, new List<Type>());
            }

            _services.AddTransient(handlerType);
            _handlersMapping[eventType].Add(handlerType);
        }

        #region Private methods
        private IEnumerable<Type> LoadHandlersForEvent<TEvent>(TEvent @event) where TEvent : DomainEvent
        {
            var eventType = @event.GetType();

            if (!_handlersMapping.ContainsKey(eventType))
            {
                return Array.Empty<Type>();
            }

            return _handlersMapping[eventType];
        }
        #endregion
    }
}
