/*function formatCurrency(value) {
    return "$" + value.toFixed(2);
}
*/
/*
var CartLine = function () {
    var self = this;
    self.category = ko.observable();
    self.product = ko.observable();
    self.quantity = ko.observable(1);
    self.subtotal = ko.computed(function () {
        return self.product() ? self.product().price * parseInt("0" + self.quantity(), 10) : 0;
    });

    // Whenever the category changes, reset the product selection
    self.category.subscribe(function () {
        self.product(undefined);
    });
};
*/

/*
var Cart = function () {    
    var CartLine = function () {var self = this;
        self.category = ko.observable();
        self.product = ko.observable();
        self.quantity = ko.observable(1);
        self.subtotal = ko.computed(function () {
            return self.product() ? self.product().price * parseInt("0" + self.quantity(), 10) : 0;
        });
   
        // Whenever the category changes, reset the product selection
        self.category.subscribe(function () {
            self.product(undefined);
        });
    };
    // Stores an array of lines, and from these, can work out the grandTotal

        //var self = this;

   // this.lines = ko.observableArray([new CartLine()]); // Put one line in by default

    this.lines = ko.observableArray([new CartLine()]); 
    this.grandTotal = ko.computed(function () {
        var total = 0;
        $.each(this.lines, function () { total += this.subtotal(); });
        return total;
    });

    // Operations
    //self.addLine = function () { self.lines.push(new CartLine()); };
    self.addLine = function () { self.lines.push(new Cart()); };
    self.removeLine = function (line) { self.lines.remove(line); };
    self.save = function () {
        var dataToSave = $.map(this.lines(), function (line) {
            return line.product() ? {
                category: "",
                productName: line.product().name,
                quantity: line.quantity(),
                subtotal: line.subtotal()

            } : undefined;
        });
        alert("Could now send this to server: " + JSON.stringify(dataToSave));
        $.ajax({
            url: 'TblOrders/AddOrder',
            dataType: 'json',
            cache: false,
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: ko.toJSON(dataToSave)
*/
           /* success: function (data) {
                this.lines.push(dataToSave);
                //self.productName("");
                //self.quantity("");
                //self.subtotal("");
                
            }
        }).fail(
            function (xhr, textStatus, err) {
                alert(err);
            */
/*
        });
    };
};

ko.applyBindings(new Cart());
*/

// Viewmodel
function formatCurrency(value) {
    return "$" + value.toFixed(2);
}

var CartLine = function () {
    var self = this;
    self.category = ko.observable();
    self.product = ko.observable();
    self.quantity = ko.observable(1);
    self.subtotal = ko.pureComputed(function () {
        return self.product() ? self.product().price * parseInt("0" + self.quantity(), 10) : 0;
    });

    // Whenever the category changes, reset the product selection
    self.category.subscribe(function () {
        self.product(undefined);
    });
};

//try using $each or some other looping method to persist multiple cart lines to the database.
var Cart = function () {
    // Stores an array of lines, and from these, can work out the grandTotal
    var self = this;
    self.lines = ko.observableArray([new CartLine()]); // Put one line in by default
    self.grandTotal = ko.pureComputed(function () {
        var total = 0;
        $.each(self.lines(), function () { total += this.subtotal(); });
        return total;
    });

    // Operations
    self.addLine = function () { self.lines.push(new CartLine()); };
    self.removeLine = function (line) { self.lines.remove(line); };
    self.save = function () {
        for (var i = 0; i < self.lines().length; i++) {
            
            // This code works to send the first cartline only to database
            /*
            var dataToSave = {
                category: ko.observable(self.lines()[0].category().name),
                product: ko.observable(self.lines()[0].product().name),
                quantity: ko.observable(self.lines()[0].quantity),
                subtotal: ko.observable(self.lines()[0].subtotal)
            };
            */

            // Trying something new to send multiple rows to server
            var dataToSave = {
                category: ko.observable(self.lines()[i].category().name),
                product: ko.observable(self.lines()[i].product().name),
                quantity: ko.observable(self.lines()[i].quantity),
                subtotal: ko.observable(self.lines()[i].subtotal)
            };
            
            $.ajax({
                url: 'TblOrders/AddOrder',
                cache: false,
                type: 'POST',
               // traditional: true,
                contentType: 'application/json; charset=utf-8',
                data: ko.toJSON(dataToSave)
            });
        }
    };
    };
ko.applyBindings(new Cart());



