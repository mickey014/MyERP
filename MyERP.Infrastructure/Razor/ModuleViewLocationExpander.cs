
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Razor;

namespace MyERP.Infrastructure.Razor
{
    public sealed class ModuleViewLocationExpander : IViewLocationExpander
    {
        private const string ModuleKey = "module";

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            if (context.ActionContext.ActionDescriptor
                is not ControllerActionDescriptor descriptor)
            {
                return;
            }

            var module = descriptor.ControllerTypeInfo
                .GetCustomAttributes(typeof(ModuleAttribute), true)
                .OfType<ModuleAttribute>()
                .FirstOrDefault()?.Name;

            module ??= GetModuleName(
                descriptor.ControllerTypeInfo.Namespace);

            if (!string.IsNullOrWhiteSpace(module))
            {
                context.Values[ModuleKey] = module;
            }
        }

        public IEnumerable<string> ExpandViewLocations(
            ViewLocationExpanderContext context,
            IEnumerable<string> viewLocations)
        {
            if (context.Values.TryGetValue(ModuleKey, out var module)
                && !string.IsNullOrWhiteSpace(module))
            {
                yield return $"/Modules/{module}/Views/{{1}}/{{0}}.cshtml";
                yield return $"/Modules/{module}/Views/Shared/{{0}}.cshtml";
            }

            foreach (var location in viewLocations)
            {
                yield return location;
            }
        }

        private static string? GetModuleName(string? controllerNamespace)
        {
            if (string.IsNullOrWhiteSpace(controllerNamespace))
            {
                return null;
            }

            var parts = controllerNamespace.Split('.');
            var index = Array.IndexOf(parts, "Modules");

            return index >= 0 && index + 1 < parts.Length
                ? parts[index + 1]
                : null;
        }
    }
}
