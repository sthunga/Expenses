var app = angular.module('expensesApp', []);
app.controller('ExpCtrl', function ($scope, $http) {
    $http.get("api/Expense")
    .success(function (response) {
        $scope.expenses = response;
    }).
    error(function (data, status, headers, config) {
        alert("");
    });

    $scope.saveExpense = function () {
        if ($valid)
            $http.post('api/Expense', $scope.newExpense)
                .success(function (response) {
                    var returnMessage = angular.fromJson(response);
                    if (returnMessage == "success") {
                        $scope.expenses.push({ ExpenseDate: $scope.newExpense.ExpenseDate, Description: $scope.newExpense.Description, Category: $scope.newExpense.Category, SubCategory: $scope.newExpense.SubCategory, ExpenseAmount: $scope.newExpense.ExpenseAmount });
                        $scope.newExpense.ExpenseDate = null;
                        $scope.newExpense.Description = '';
                        $scope.newExpense.Category = '';
                        $scope.newExpense.SubCategory = '';
                        $scope.newExpense.ExpenseAmount = '';
                    }
                    else {

                    }
                })
                .error(function (data, status, headers, config) {
                    alert("");
                });
    };
});
