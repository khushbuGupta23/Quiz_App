var app = angular.module('UploadBulkModule', []);

app.service('UploadBulkService', function ($http, $location) {


    this.AppUrl = "";

    console.log($location.absUrl());

    if ($location.absUrl().indexOf('FB') != -1) {

        this.AppUrl = "/FB/api/"

    }
    else {

        this.AppUrl = "/api/"
    }

    this.UploadExcel = function (fd) {
        return $http.post(this.AppUrl + "QuestionBank/UploadExcel", fd, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        });
    };

});
app.controller('UploadBulkController', function ($scope, $http, $location, UploadBulkService, $rootScope) {

    $scope.Role = '';
    $rootScope.init = function () {
        console.log('inside init');
        $scope.showForm = false;
        $scope.showEditForm = false;

        $scope.Role = angular.fromJson(sessionStorage.getItem("app")).UserName;
        $scope.User_Id = angular.fromJson(sessionStorage.getItem("app")).User_Id;

    };

    
    $scope.UploadBulkExcel = function () {
       
        console.log("upload");
        var file = $scope.myFile;

        console.log(file);
        var fd = new FormData();
        console.log(fd);
        fd.append('file', file);

        console.log(file);
        if (file) {

            var obj = {
                User_Id: $scope.User_Id,
               
            };

            fd.append('data', angular.toJson(obj));
            console.log(fd);

            UploadBulkService.UploadExcel(fd).then(function (success) {

                //UploadProduct.ReportDetails = success.data;
                console.log("$scopeReport", success);
                debugger;
                $scopeReport = success.data
                console.log("$scopeReport", success.data);
                if ($scopeReport.Message == 'Success') {
                    swal("Data Uploaded Successfully!");
                    fd.append ='';
                }
                else {
                    swal($scopeReport.Message);
                    return false;
                }

            },
                function (error) {
                    console.log(error);
                    swal("Error");
                });
        }
        else {
            swal("", "Please upload Attachment", "error");
        }

    };

    $rootScope.init();
});



