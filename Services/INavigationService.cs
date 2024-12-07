namespace maui_music_application.Services;

public interface INavigationService
{
    Task Push(Page page);
    Task<Page> Pop();
    void InsertPageBefore(Page page, Page before);
    void InsertPageAfter(Page page, Page after);
    Task Replace(Type page);
    Task PopToRoot();
    void ClearBackStack();
    Task PushModal(Page page);
    Task<Page> PopModal();
    Task PushAndRemovePage(Page page, List<Type> pageRemoves);
    void RemovePage(Type typePage);
    void RemovePages(List<Type> pageRemoves);
    Task PopAndClearAllButKeep(List<Type> pagesToKeep);
    Task InsertOnTop(Type typePage);
    Task InsertOnTop(Page page);
}