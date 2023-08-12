
$(document).ready(function () {
    GetToken();
});
var userName = "alireza@gmail.com";
var password = "123456";
var token;

function GetToken() {
    if (!userName || !password) {
        console.log("username or password null");
        return;
    }
    $.ajax({
        cache: false,
        type: 'Post',
        headers: {
            "accept": "text/plain",
            "Content-Type": "application/json",
        },
        data: JSON.stringify({
            "guest": true,
            "username": userName,
            "password": password,
            "remember_me": true
        }),
        url: "/token",
        success: function (response) {
            token = response.access_token;
            GetProducts();
            console.log(token);
        }
    });
}

function GetProducts() {
    var _url = "/api/products";
    $.ajax({
        cache: false,
        type: "GET",
        headers: {
            Authorization: "Bearer " + token,
        },
        url: _url,
        success: function (response) {
            response = response.products;
            var holderTempelet = $("#table_holder");
            $("#table_holder").empty();
            for (let i = 0; i < response.length; i++) {
                var appendTempelet = $("#table_append").html();
                appendTempelet = appendTempelet.replace(/#Id#/g, response[i].id)
                    .replace(/#Index#/g, i + 1)
                    .replace(/#Image#/g, "Image")
                    .replace(/#Name#/g, response[i].name)
                    .replace(/#Sku#/g, response[i].sku)
                    .replace(/#Price#/g, response[i].price)
                    .replace(/#StockQuantity#/g, response[i].stock_quantity);
                holderTempelet.append(appendTempelet);
            }
        }
    });
}
function GetProductById(id) {
    var obj = {};
    var _url = "/api/products/" + id;
    $.ajax({
        caches: false,
        type: "GET",
        headers: {
            Authorization: "Bearer " + token,
        },
        data: { id: id },
        url: _url,
        success: function (response) {
            obj = response.products;
        }
    });
    return obj;
}

function GetProductByCategoty() {
    var _url = "/api/products/categories";
    $.ajax({
        caches: false,
        type: "GET",
        headers: {
            Authorization: "Bearer " + token,
        },
        url: _url,
        success: function (response) {

        }
    });
}

function GetCount() {
    var _url = "/api/products/count";
    $.ajax({
        caches: false,
        type: "GET",
        headers: {
            Authorization: "Bearer " + token,
        },
        url: _url,
        success: function (response) {

        }
    });
}

function Save() {
    var _url = "/api/products";
    var _id = $("#txtId").val();
    if (_id > 0) {
        _url = _url + _id;
    }
    $.ajax({
        caches: false,
        type: "POST",
        headers: {
            Authorization: "Bearer " + token,
        },
        url: _url,
        success: function (response) {

        }
    });
}

function Delete() {
    var _url = "/api/products/{id}";
    $.ajax({
        caches: false,
        type: "POST",
        headers: {
            Authorization: "Bearer " + token,
        },
        url: _url,
        success: function (response) {

        }
    });
}

function Update(id) {
    var product = GetProductById(id);
    $("#txtId").val(product[0].Id);
    $("#txtName").val(product[0].Name);
    $("#txtSku").val(product.Id);
    $("#txtPrice").val(product.Id);
    $("#txtStockQuantity").val(product.Id);
    $("#txtId").val(product.Id);
    console.log(ddd);
}