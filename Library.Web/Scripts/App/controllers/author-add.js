(function () {
    'use strict';

    angular
        .module('app')
        .controller('AuthorAddController', AuthorAddController);

    AuthorAddController.$inject = ['$scope', '$location', 'Author'];

    function AuthorAddController($scope, $location, Author) {
        $scope.author = new Author();

        $scope.editAuthor = function () {
            if (!$scope.form.$valid)
                return;

            $scope.author.$save(function () {
                $location.path('/authors');
            }, function (e) {
                $scope.validationErrors = e.data.Errors;
            });
        };
    }
})();