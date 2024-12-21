namespace maui_music_application.Services.impl;

public class NavigationService(INavigation navigation) : INavigationService
{
    public Task Push(Page page)
    {
        return navigation.PushAsync(page);
    }

    public Task<Page> Pop()
    {
        return navigation.PopAsync();
    }

    public void InsertPageBefore(Page page, Page before)
    {
        navigation.InsertPageBefore(page, before);
    }

    public void InsertPageAfter(Page page, Page after)
    {
        var navigationStack = navigation.NavigationStack;
        for (var i = 0; i < navigationStack.Count; i--)
        {
            var p = navigationStack[i];
            if (p == null) continue;
            if (!(after.GetType() == p.GetType())) continue;
            InsertPageBefore(page, i == 0 ? p : navigationStack[i - 1]);
            return;
        }

        navigation.PushAsync(page);
    }

    public Task Replace(Type page)
    {
        return Shell.Current.GoToAsync($"//{page}");
    }

    public Task PopToRoot()
    {
        return navigation.PopToRootAsync();
    }

    public void ClearBackStack()
    {
        var navigationStack = navigation.NavigationStack;
        for (var i = navigationStack.Count - 2; i >= 0; i--)
        {
            var page = navigationStack[i];
            if (page == null) continue;
            navigation.RemovePage(page);
        }
    }

    public Task PushModal(Page page)
    {
        return navigation.PushModalAsync(page);
    }

    public Task<Page> PopModal()
    {
        return navigation.PopModalAsync();
    }

    public Task PushAndRemovePage(Page page, List<Type> pageRemoves)
    {
        RemovePages(pageRemoves);
        return navigation.PushAsync(page);
    }

    public void RemovePage(Type typePage)
    {
        RemovePages([typePage]);
    }

    public void RemovePages(List<Type> pageRemoves)
    {
        var navigationStack = navigation.NavigationStack;
        for (var i = navigationStack.Count - 2; i >= 0; i--)
        {
            var page = navigationStack[i];
            if (page == null) continue;
            if (!pageRemoves.Contains(page.GetType())) continue;
            navigation.RemovePage(page);
        }
    }

    public Task PopAndClearAllButKeep(List<Type> pagesToKeep)
    {
        var navigationStack = navigation.NavigationStack;
        for (var i = navigationStack.Count - 2; i >= 0; i--)
        {
            var page = navigationStack[i];
            if (page == null) continue;
            if (pagesToKeep.Contains(page.GetType())) continue;
            navigation.RemovePage(page);
        }

        return navigation.PopAsync();
    }

    public Task InsertOnTop(Type typePage)
    {
        ClearBackStack();
        return Replace(typePage);
    }

    public async Task InsertOnTop(Page page)
    {
        await navigation.PushAsync(page);
        ClearBackStack();
    }
}