var app = angular.module('expensesApp', []);
app.controller('ExpCtrl', function ($scope, $http) {
    $http.get("api/Expense")
    .success(function (response) { $scope.expenses = response; }).
  error(function (data, status, headers, config) {
      //Do some error handling here
  });
});