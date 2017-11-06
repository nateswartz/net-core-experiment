function BookViewModel() {
    var self = this;
    self.id = ko.observable('');
    self.Author = ko.observable('');
    self.Title = ko.observable('');
    self.Image = ko.observable('');
    self.Type = ko.observable('');
};