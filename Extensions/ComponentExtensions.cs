using RoboMate.Controller;
using RoboMate.Controller.Components;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RoboMate.Extensions
{
	public static class ComponentExtensions
	{
		public static string GetIdentifier(this IComponent component)
		{
			return component.GetType().GetCustomAttribute<ComponentAttribute>()?.Identifier;
		}
	}
}
