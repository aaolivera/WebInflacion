function Material(id,nombre, canasta) {
    this.Nombre = nombre;
    this.Id = id;
    this.Eliminar = function () {
        canasta.remove(this);
    }
};

function ViewModel() {
    var self = this;
    self.canasta = ko.observableArray([]);
    self.myValue = ko.observable();
    self.getOptions = function (searchTerm, callback) {
        $.ajax({
            dataType: "json",
            url: actionUrl,
            data: {
            query: searchTerm
            },
            }).done(callback);
    };

    self.agregar = function()
    {
        var nombre = self.myValue().split("*")[1];
        var id = self.myValue().split("*")[0];
        
        var match = ko.utils.arrayFirst(self.canasta(), function (item) {
            return id === item.Id;
        });

        if (!match) {
            self.canasta.push(new Material(id, nombre, self.canasta));
        }
        self.myValue(null);
    }
};

$(document).ready(function () {
    ko.applyBindings(new ViewModel());
});
