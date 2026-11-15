namespace MyERP.Domain.Enums
{
    /// <summary>Matches Section 18 of the brief.</summary>
    public enum InventoryTransactionType
    {
        Purchase = 0,
        Sale = 1,
        Return = 2,
        Adjustment = 3,
        Transfer = 4
    }

}
