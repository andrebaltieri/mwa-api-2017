using System;
using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commands
{
    public class RegisterOrderItemCommand : ICommand
    {
        public Guid Product { get; set; }
        public int Quantity { get; set; }
    }
}
