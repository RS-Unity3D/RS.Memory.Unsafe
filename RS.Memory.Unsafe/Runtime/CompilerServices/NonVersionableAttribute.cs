using System;

namespace RS.MemoryUnsafe.Internals
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	public sealed class NonVersionableAttribute : Attribute
	{
	}
}
