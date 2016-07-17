(function () {
    'use strict';

    angular
        .module('authorService', ['ngResource'])
        .factory('Author', Author);

    Author.$inject = ['$resource'];

    function Author($resource) {
        var res = $resource('/api/Author/:id', null, {
            'create': { method:'POST' },
            'update': { method:'PUT' }
        });

        res.prototype.$save = function (params, success, error) {
            if (this.Id) {
                return this.$update(params, success, error);
            } else {
                return this.$create(params, success, error);
            }
        };
        
        return res;
    }
})();