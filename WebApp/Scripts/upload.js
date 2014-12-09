(function () {

    function Upload() {
        this.formData = {};
    }

    Upload.prototype.change = function (e) {
        var files = e.target.files;
        for(var l = files.length; l--;)
        {
            var file = files[l];
            this.formData[file.name] = file;
        }
    };

    Upload.prototype.send = function () {
        $.ajax({
            type: 'POST',
            url: 'excel/upload',
            contentType: 'multipart/form-data',
            data: toFormData(this.formData),
            success: this.success,
            error: this.error
        });
    };

    Upload.prototype.success = function (data) {
        debugger;
        alert('upload realizado com sucesso. \n Verifique os objetos retornados no console.');
        console.log(data);
    };

    Upload.prototype.success = function (xhr, status, error) {
        debugger;
        alert('Ocorreu um erro. \n Verifique o erro retornado no console.');
        console.log('erro: %s - status: %s', error, status);
    };

    function toFormData(items) {
        var formData = new FormData();

        for (var item in items)
        {
            formData.append(item, items[item]);
        }

        return formData;
    }

    window.Upload = Upload;
})();