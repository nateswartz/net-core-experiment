function StarshipViewModel(name, model, manufacturer, cost, length, hyperdriverating, mglt) {
    var self = this;
    self.Name = ko.observable(name);
    self.Model = ko.observable(model);
    self.Manufacturer = ko.observable(manufacturer);
    self.Cost_In_Credits = ko.observable(cost);
    self.Length = ko.observable(length);
    self.Hyperdrive_Rating = ko.observable(hyperdriverating);
    self.MGLT = ko.observable(mglt);
};