namespace SuperAutoMachines.Gui
{
    public interface IStoreGui
    {
        Task DrawMenuAndAwait();
        Task DrawBuyOptionAndAwait();
        Task DrawMachineAssignAndAwait();
        Task DrawSellOptionAndAwait();
    }
}