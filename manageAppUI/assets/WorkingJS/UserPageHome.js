var app = angular.module('UserHomeModule', ['ngLoadingSpinner', 'ngRoute', 'ngCookies', 'levelModule']);

app.service('LoginService', function ($http, $location) {
    this.AppUrl = "/api/";
    this.getSubject = function () {
        return $http.get(AppUrl + '/Subject/GetList');
    };

});


app.config(function ($routeProvider, $httpProvider, $locationProvider) {
    $locationProvider.hashPrefix('');
    $routeProvider
        .when('/Subject', {
            templateUrl: '/assets/HTML/SubjectManage.html',
            controller: 'SubjectController'
        });
});

app.controller('UserHomeController', function ($scope, $q, $http, LoginService, $location, $cookies, $rootScope) {
   

    $rootScope.init = function () {
        var deferred = $q.defer();
        console.log("at homecontroller");
        var array = location.search.substring(1).split('=');
        var KEy = '';
        var Value = '';
        if (array.length > 0) {
            KEy = array[0];
            Value = array[1];
        }
        if (KEy == 'udi') {
            var obj = {
                Oth_key: Value,
            };
            $scope.Emp = Value;
        }
      
        SubjectService.List().then(function (response) {
            console.log("res", response);

            $scope.roleId == 1 ? $scope.ShowEdit = true : $scope.ShowEdit = false;
            $scope.roleId == 1 ? $scope.ShowDelete = true : $scope.ShowDelete = false;
            $scope.roleId == 1 ? $scope.ShowAdd = true : $scope.ShowAdd = false;
            $scope.subjectList = response.data;
            console.log("subId", $scope.subjectList);
            console.log("init");

        });

        

    };
    $scope.ClickButton = function () {
        window.location = '/assets/HTML/QuestionBank.html';
    };
})