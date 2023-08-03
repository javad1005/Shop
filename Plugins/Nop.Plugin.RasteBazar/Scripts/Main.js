//import React, { useState, userEffect } from 'react';
//import { precacheAndRoute, createHandlerBoundToURL } from 'workbox-precaching';

//export default function MyApp() {
//  return (
//    <div>
//      <h1>Welcome to my app</h1>
//      <MyButton />
//    </div>
//  );
//}

//function MyButton() {
//  return (
//    <button>
//      I'm a button
//    </button>
//  );
//}

$(document).ready(function () {
  GetCustomers();
});
function GetCustomers() {
  $.ajax({
    cache: false,
    type: 'GET',
    url: "/api/customers",
    success: function (data) {
      window.alert(data);
    }
  });
}