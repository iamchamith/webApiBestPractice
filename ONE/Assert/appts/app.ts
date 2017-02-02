/// <reference path="bean.ts" />

module One {

    var student = (function () {
        const url = "/api/StudentService/";
        var $studentViewModel = new kendo.data.ObservableObject();
        function insert_(e: any) {

            var d: any;
            d.Address ="aaa";
            d.Dob = "1988-8-8";
            d.Email = "iamchamith@gmail.com";
            d.Name = "janson";
            d.Phone ="123132132";


            return $.ajax({
                url: url + 'Insert',
                method: 'post',
                data: JSON.stringify(e)
            });
        }
        function update_(e) {
            return $.ajax({
                url: '',
                method: 'put',
                data: JSON.stringify(e)
            });
        }
        function delete_(e) {
            return $.ajax({
                url: '',
                method: 'delete',
                data: JSON.stringify(e)
            });
        }
        function get_(e?) {
            return $.ajax({
                url: url + 'Get',
                method: 'get',
                data: e
            });
        }
        function getSingle_(e) {
            return $.ajax({
                url: url + 'GetSingle',
                method: 'get',
                data: { studentId: e }
            });
        }
        function setMvvm(e: MVVM.Student) {
            $studentViewModel = kendo.observable({
                Name: e.Name,
                Address: e.Address,
                Phone: e.Phone,
                Email: e.Email,
                Dob: e.Dob,
                IsVisibleSave: e.IsVisibleSave,
                IsVisibleUpdate: e.IsVisibleUpdate,
                IsVisibleDelete: e.IsVisibleDelete,
                Insert: (p) => {

                    if (confirm('sure insert?')) {

                        insert_(p.data).done((e) => {
                            alert('success');
                        });
                    }

                },
                Update: () => { alert('Update'); },
                Delete: () => { alert('Delete'); }
            });
        }
        function ModelOpen(e: MVVM.Student) {
            setMvvm(e);
            kendo.bind($("#frmStudent"), $studentViewModel);
            $("#frmStudent").modal('show').appendTo('body');
        }
        return {
            init: () => {
                $("#main-placeHolder").html($("#template-student").html());
                $('#btnCreateStudentModelOpen').off().bind('click', null, () => {
                    var e = new MVVM.Student();
                    e.IsVisibleSave = true;
                    e.IsVisibleUpdate = false;
                    e.IsVisibleDelete = false;
                    ModelOpen(e);
                });
                $('#gv-student').kendoGrid({
                    columns: [
                        { field: "Id", hidden: true },
                        { field: "Name" },
                        { field: "Email" },
                        {
                            command: [{
                                name: "details",
                                click: function (e) {
                                    e.preventDefault();
                                    var tr = $(e.target).closest("tr");
                                    var data = this.dataItem(tr);
                                    console.log("Details for: " + data.Id);

                                    getSingle_(data.Id).done((e: MVVM.Student) => {
                                        e.IsVisibleSave = false;
                                        e.IsVisibleUpdate = true;
                                        e.IsVisibleDelete = true;
                                        ModelOpen(e);
                                    });

                                }
                            }]
                        }
                    ],
                });
                $('#dtStudentDob').kendoDatePicker();
                student().get();
            },
            get: () => {
                get_().done((e) => {
                    $('#gv-student').data("kendoGrid").setDataSource(new kendo.data.DataSource({ data: e }));
                });
            }
        };
    });

    var subject = (function () {

        function insert() {
            return $.ajax({});
        }
        function update() {
            return $.ajax({});
        }
        function delete_() {
            return $.ajax({});
        }
        function get() {
            return $.ajax({});
        }
        return {
            init: () => {

            },
            get: () => {

            },
            insert: () => {

            },
            update: () => {

            }
        };
    });

    function load() {
        $('.menu').bind('click', (e) => {

            if ($(e.target).attr('data-bind') == 'student') {
                student().init();
            } else {
                subject().init();
            }
        });
        student().init();
    }

    $(() => { load(); });
}