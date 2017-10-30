function StarshipViewModel(data) {
    var self = this;
    self.Name = ko.observable(data.Name);
    self.Model = ko.observable(data.Model);
    self.Manufacturer = ko.observable(data.Manufacturer);
    self.Cost = ko.observable(data.Cost_In_Credits);
    self.Length = ko.observable(data.Length);
    self.HyperdriveRating = ko.observable(data.Hyperdrive_Rating);
    self.MGLT = ko.observable(data.MGLT);

    self.FormattedCost = ko.computed(function () {
        return self.Cost().toLocaleString({ useGrouping: true });
    }, self);
};