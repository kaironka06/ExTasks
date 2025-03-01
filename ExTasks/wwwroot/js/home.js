

function eliminar(id) {
   
        if (confirm("¿Desea eliminar?") {
            //TODO: Funcionalidad para eliminar usuario.
            $.ajax({
                type: "POST",
                url: "Eliminar",
                data: { "tarea": id },

                success: function (e) {
                    if (e.ok) {
                        alert("Registro eliminado")
                        setTimeout(function () { window.location.reload(); }, 1000);
                    }
                    else {
                        alert("Ocurrio un error");
                    }
                },
                error: function (data) {
                    alert("Ocurrio un error");
                    //window.location.href = "/login";
                }
            });

        } else {
            //TODO: Otra funcionalidad en caso de cancelar.
        }

}