function ArticleViewModel() {
    var self = this;
    self.Author = ko.observable('');
    self.Title = ko.observable('');
    self.Description = ko.observable('');
    self.Url = ko.observable('');
    self.UrlToImage = ko.observable('');
    self.PublishedAt = ko.observable('');
};