import { IMSTemplatePage } from './app.po';

describe('IMS App', function() {
  let page: IMSTemplatePage;

  beforeEach(() => {
    page = new IMSTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
