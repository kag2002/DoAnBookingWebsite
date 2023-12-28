import { BookingWebsiteTemplatePage } from './app.po';

describe('BookingWebsite App', function() {
  let page: BookingWebsiteTemplatePage;

  beforeEach(() => {
    page = new BookingWebsiteTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
