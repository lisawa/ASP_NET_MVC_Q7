window.onload = function () {

    var vm = new Vue({
        el: '#vueApp',
        data: {
            message: 'Hello',
            todoList: [{
                topic: 'aaa',
                status: false,
            }],
            todoTopic: '',
            count: '',
            showStatus: 0,
        },
        beforeCreate: function () {
            var vm = this;
            $.ajax({
                url: '/Todo/GetList',
                type: 'POST',
                success: function (res) {
                    var data = JSON.parse(res);
                    console.log(data);
                    vm.todoList = data.TodoItemList;
                },
                error: function (res) {
                    console.log(res);
                }
            });
        },
        methods: {
            check: function () {
                $.ajax({
                    url: '/Todo/AddNewTopic',
                    type: 'POST',
                    data: {
                        topic: this.todoTopic,
                    },
                    success: function (res) {
                        var data = JSON.parse(res);
                        console.log(data);
                        vm.todoList = data.TodoItemList;
                    },
                    error: function (res) {
                        console.log(res);
                    }
                });
                this.todoTopic = '';
            },
            update: function (i) {
                $.ajax({
                    url: '/Todo/UpdateStatus',
                    type: 'POST',
                    data: {
                        id: i.ID,
                        status: i.Status,
                    },
                    success: function (res) {
                        var data = JSON.parse(res);
                        vm.todoList = data.TodoItemList;
                    },
                    error: function (res) {
                    }
                });
            },
            remove: function (i) {
                $.ajax({
                    url: '/Todo/RemoveShow',
                    type: 'POST',
                    data: { id: i.ID },
                    success: function (res) {
                        var data = JSON.parse(res);
                        vm.todoList = data.TodoItemList;
                    },
                    error: function (res) {
                    }
                });
            },
            hideAllFinish: function () {
                $.ajax({
                    url: '/Todo/HideAllFinish',
                    type: 'POST',
                    success: function (res) {
                        var data = JSON.parse(res);
                        vm.todoList = data.TodoItemList;
                    },
                    error: function (res) {
                    }
                });
            },
            checkShow: function (i) {
                switch (this.showStatus) {
                    case 0:
                        return true;
                    case 1:
                        return i === true;
                    case 2:
                        return i === false;
                }
            },
            changeShowStatus: function (i) {
                this.showStatus = i;
            }
        }
    })
}

