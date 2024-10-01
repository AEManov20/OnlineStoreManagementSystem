namespace OnlineStoreManagementSystem;

interface ISalesManageable
{
    /// <summary>
    /// Adds a certain amount of the given Manageable
    /// </summary>
    /// <param name="amount">amount to add</param>
    public void AddQuantity(uint amount);

    /// <summary>
    /// Sells/Removes a certain amount of the given Manageable
    /// </summary>
    /// <param name="amount">amount to remove/sell</param>
    /// <returns>Whether the amount could be removed/sold or not.</returns>
    public bool RemoveQuantity(uint amount);
}