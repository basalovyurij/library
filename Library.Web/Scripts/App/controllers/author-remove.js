(function () {
    'use strict';

    angular
        .module('app')
        .controller('AuthorDeleteController', AuthorDeleteController);

    AuthorDeleteController.$inject = ['$scope', '$routeParams', '$location', 'Author'];

    function AuthorDeleteController($scope, $routeParams, $location, Author) {
        $scope.author = Author.get({ id: $routeParams.id });
        $scope.remove = function () {
            $scope.author.$remove({ id: $scope.author.Id }, function () {
                $location.path('/authors');
            });
        };
    }
})();