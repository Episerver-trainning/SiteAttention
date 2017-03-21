# SiteAttention
Try to customize SiteAttention

# Episerver account:
 admin / 12345678aA@

# Limitation

Only work when change data of content area of the property **Large content area** of the Start Page :)

A lot of things need to re-do or refactor.

# How to test
- Open the Inspect in the browser.
- Access the Editor interface.
- Open the start page.
- Switch to the all properties view.
- Change the **Large content area**
- Check the output in the console log in the browser and in the SiteAttention Widget.

# Render with Tag in the TemplateCoordinate
**Assumption**: 
- The page ussually use only one tag for itself.
- When we view a page in the Editor Interface, it always open the preview page first.

**Solution**:
- The Tag of Episerver can get from the ViewData.
- Implement IResultFilter. In OnResultExecuted store the Tag to cookie.
- Use tag in the cookie when we render content area for SiteAttention.

# Render with Personalization
- If we use the personalization with cookie value. It works with current solution.

