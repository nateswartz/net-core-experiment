var StarshipModel = (function () {
    var addComputed = function (data) {
        ko.mapping.fromJS(data, {}, this);

        this.FormattedCost = ko.computed(function () {
            return this.Cost_In_Credits().toLocaleString({ useGrouping: true });
        }, this);
    }

    var map = {
        create: function (options) {
            return new addComputed(options.data);
        }
    }

    return {
        map: map
    };
})();