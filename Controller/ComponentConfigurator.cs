using RoboMate.Controller.Components;
using RoboMate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace RoboMate.Controller
{
    public class ComponentConfigurator
    {
        private ComponentRepository componentRepository;
        private ManualResetEvent manualResetEvent;

        private static ComponentConfigurator componentConfigurator;
        public static ComponentConfigurator GetComponentConfigurator()
        {
            componentConfigurator ??= new ComponentConfigurator();
            return componentConfigurator;
        }
        private ComponentConfigurator()
        {
            componentRepository = new ComponentRepository();
        }
        public bool Suspended { get; set; }
        public void Initialize(Configurations configuration)
        {
            manualResetEvent = new ManualResetEvent(true);
            ConfigureComponents(configuration);
            Suspended = false;
            new Thread(UpdateMateMovementBehaviour).Start();
        }

        private void UpdateMateMovementBehaviour()
        {
            while (true)
            {
                manualResetEvent.WaitOne();
                StartRandomMovement();
                Thread.Sleep(10000);
            }
        }

        public List<string> GetAllComponentIdentifier()
        {
            return GetAllComponentTypes()
                .Select(c => c.GetCustomAttribute<ComponentAttribute>().Identifier)
                .ToList();
        }

        private IEnumerable<Type> GetAllComponentTypes()
        {
            var componentAssembly = typeof(IComponent).GetTypeInfo().Assembly;
            return componentAssembly.GetTypes()
                .Where(c => !string.IsNullOrEmpty(c.GetCustomAttribute<ComponentAttribute>()?.Identifier));
        }

        public void ReconfigureComponents(Configurations configuration)
        {
            var activeComponents = componentRepository.GetActiveCoponents();

            var componentsToRemove = activeComponents.Where(c => !configuration.EnabledComponents.Contains(c));
            foreach (var component in componentsToRemove)
            {
                componentRepository.Remove(component);
            }
            ConfigureComponents(configuration);
        }

        private void ConfigureComponents(Configurations configuration)
        {
            var components = GetAllComponentTypes()
                   .Where(c => configuration.EnabledComponents.Contains(c.GetCustomAttribute<ComponentAttribute>().Identifier))
                   .ToList();
            foreach (var component in components)
            {
                var newComponent = (IComponent)Activator.CreateInstance(component);
                componentRepository.InsertOrUpdate(newComponent);
                if (Suspended)
                    newComponent.SuspendComponent();
            }
            if (!Suspended)
                StartRandomMovement();
        }

        private void StartRandomMovement()
        {
            var movementComponents = componentRepository.GetAllMovementComponent();
            foreach (var movementComponent in movementComponents)
            {
                movementComponent.SuspendComponent();
            }
            if (movementComponents.Count > 0)
                movementComponents[new Random().Next(movementComponents.Count)].ResumeComponent();
        }

        public void SuspendAllComponents()
        {
            manualResetEvent.Reset();
            Suspended = true;
            foreach (var component in componentRepository.GetComponents())
            {
                component.SuspendComponent();
            }
        }

        public void ResumeAllComponents()
        {
            manualResetEvent.Set();
            Suspended = false;
            foreach (var component in componentRepository.GetComponents())
            {
                component.ResumeComponent();
            }
            StartRandomMovement();
        }
    }
}
