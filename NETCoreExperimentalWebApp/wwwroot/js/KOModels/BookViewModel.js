function BookViewModel(id, author, title, image, type) {
    var self = this;
    self.id = ko.observable(id);
    self.Author = ko.observable(author);
    self.Title = ko.observable(title);
    self.Image = ko.observable(image);
    self.Type = ko.observable(type);
};