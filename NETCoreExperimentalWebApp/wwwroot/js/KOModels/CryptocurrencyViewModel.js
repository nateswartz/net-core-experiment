function CryptocurrencyViewModel(data) {
    var self = this;
    self.Name = ko.observable(data.Name);
    self.Symbol = ko.observable(data.Symbol);
    self.Price = ko.observable(data.Price_USD);
    self.PercentChangeOneHour = ko.observable(data.percent_change_1h);
    self.PercentChangeOneDay = ko.observable(data.percent_change_24h);
    self.PercentChangeOneWeek = ko.observable(data.percent_change_7d);

    self.FormattedPrice = ko.computed(function () {
        if (self.Price() !== null) {
            return self.Price().toLocaleString('en-US', { style: 'currency', currency: 'USD' });
        }
        return null;
    }, self);
};
