document.addEventListener('DOMContentLoaded', function () {
    var UrlsImagenes = [];
    var variTotalValorInsumos = 0;
    var variSubtotalCompra = 0;
    var camposLlenos = false;

    var btnAgregarInputs = document.getElementById("btnAgregarInputs");
    var btnEnviarDatos = document.getElementById("btnEnviarDatos");

    btnAgregarInputs.addEventListener("click", function () {
        if (!validarCamposCompra()) {
            return;
        }
        if (!validarCamposInsumos()) {
            return;
        }
        agregarInputs();
    });

    btnEnviarDatos.addEventListener("click", function () {
        if (UrlsImagenes.length === 0) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'No se puede registrar la compra porque no hay insumos asociados.',
            });
            return;
        }

        Swal.fire({
            title: '¿Estás seguro?',
            text: "Se registrarán los datos.",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sí, registrar',
            cancelButtonText: 'Cancelar'
        }).then((result) => {
            if (result.isConfirmed) {
                enviarDatos();
            }
        });
    });

    function agregarInputs() {
        $('#FechaCompra').prop('disabled', true);
        $('#DescuentoCompra').prop('disabled', true);
        $('#IvaCompra').prop('disabled', true);

        var ValorImagenInsumo = document.getElementById("ImagenInsumo").value;
        var ValorNombreInsumo = document.getElementById("NombreInsumo").value;
        var ValorCantidadInsumo = document.getElementById("CantidadInsumo").value;
        var ValorUsosDisponibles = document.getElementById("UsosDisponibles").value;
        var ValorCategoria = document.getElementById("Categoria").value;
        var ValorPrecioUnitario = document.getElementById("PrecioUnitario").value;
        var ValorIdProveedor = document.getElementById("IdProveedor").value;

        if (ValorImagenInsumo === "" || ValorNombreInsumo === "" || ValorCantidadInsumo === "" || ValorUsosDisponibles === "" || ValorCategoria === "" || ValorPrecioUnitario === "" || ValorIdProveedor === "") {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: '¡Todos los campos de insumos deben estar llenos!',
            });
            return;
        }

        UrlsImagenes.push(ValorImagenInsumo);

        var tablaBody = document.getElementById("tablaInsumosBody");

        var newRow = tablaBody.insertRow();
        var cols = [];
        for (var i = 0; i < 7; i++) {
            cols[i] = newRow.insertCell(i);
        }

        // Insertar la imagen en la primera celda
        var img = document.createElement("img");
        img.src = ValorImagenInsumo;
        img.style.maxWidth = "100px";
        img.style.borderRadius = "50%";
        img.style.width = "80px";
        img.style.height = "80px";
        cols[0].appendChild(img);

        cols[1].innerText = ValorCategoria;
        cols[2].innerText = ValorNombreInsumo;
        cols[3].innerText = ValorCantidadInsumo;
        cols[4].innerText = ValorPrecioUnitario;
        cols[5].innerText = ValorUsosDisponibles;
        cols[6].innerText = ValorIdProveedor;

        var btnEliminar = document.createElement("button");
        btnEliminar.classList.add("btn", "btn-danger");
        var iconoEliminar = document.createElement("i");
        iconoEliminar.classList.add("fas", "fa-trash");
        btnEliminar.appendChild(iconoEliminar);

        btnEliminar.onclick = function () {
            eliminarFila(newRow);
        };

        cols[7] = newRow.insertCell(7);
        cols[7].appendChild(btnEliminar);

        document.getElementById("ImagenInsumo").value = '';
        document.getElementById("NombreInsumo").value = '';
        document.getElementById("CantidadInsumo").value = '';
        document.getElementById("UsosDisponibles").value = '';
        document.getElementById("Categoria").value = '';
        document.getElementById("PrecioUnitario").value = '';

        calcularTotalYSubtotal();
    };

    function eliminarFila(fila) {
        var tablaBody = fila.parentNode;

        var precioUnitario = parseFloat(fila.cells[4].innerText);
        var cantidad = parseFloat(fila.cells[3].innerText);

        fila.parentNode.removeChild(fila);

        variTotalValorInsumos -= precioUnitario * cantidad;
        document.getElementById("TotalValorInsumos").value = variTotalValorInsumos;
        calcularTotalYSubtotal();
    }

    function calcularTotalYSubtotal() {
        var iva = parseFloat(document.getElementById("IvaCompra").value);
        var descuento = parseFloat(document.getElementById("DescuentoCompra").value);

        var total = 0;
        var preciosUnitarios = Array.from(document.querySelectorAll("#tablaInsumosBody tr td:nth-child(5)"));
        var cantidades = Array.from(document.querySelectorAll("#tablaInsumosBody tr td:nth-child(4)"));

        for (var i = 0; i < preciosUnitarios.length; i++) {
            total += parseFloat(preciosUnitarios[i].innerText) * parseFloat(cantidades[i].innerText);
        }

        variTotalValorInsumos = total;
        document.getElementById("TotalValorInsumos").value = total;

        variSubtotalCompra = (total + iva) - descuento;
        document.getElementById("SubtotalCompra").value = variSubtotalCompra;
    }

    function enviarDatos() {
        if (!validarCamposCompra()) {
            return;
        }
        var datos = {
            arrayImagenInsumo: UrlsImagenes,
            arrayNombreInsumo: obtenerColumna(2),
            arrayCantidadInsumo: obtenerColumna(3).map(Number),
            arrayUsosDisponibles: obtenerColumna(5).map(Number),
            arrayPrecioUnitario: obtenerColumna(4).map(Number),
            arrayCategoria: obtenerColumna(1),
            arrayIdProveedor: obtenerColumna(6).map(Number),
            variFechaCompra: new Date(document.getElementById("FechaCompra").value),
            variDescuentoCompra: parseFloat(document.getElementById("DescuentoCompra").value),
            variIvaCompra: parseFloat(document.getElementById("IvaCompra").value),
            variTotalValorInsumos: variTotalValorInsumos,
            variSubtotalCompra: variSubtotalCompra,
            variEstadoCompra: document.getElementById("EstadoCompra").value
        };

        $.ajax({
            url: '/Compras/Create',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(datos),
            success: function (response) {
                // Manejar la respuesta del servidor 
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
                // Manejar errores de la solicitud
            }
        });
    }

    function validarCamposCompra() {
        var camposCompraLlenos = false;

        if ($('#FechaCompra').val() !== "" && $('#DescuentoCompra').val() !== "" && $('#IvaCompra').val() !== "") {
            camposCompraLlenos = true;
        }

        if (!camposCompraLlenos) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: '¡Todos los campos de la información de la compra deben estar llenos!',
            });
            return false;
        }

        return true;
    }

    function validarCamposInsumos() {
        var ValorImagenInsumo = document.getElementById("ImagenInsumo").value;
        var ValorNombreInsumo = document.getElementById("NombreInsumo").value;
        var ValorCantidadInsumo = document.getElementById("CantidadInsumo").value;
        var ValorUsosDisponibles = document.getElementById("UsosDisponibles").value;
        var ValorCategoria = document.getElementById("Categoria").value;
        var ValorPrecioUnitario = document.getElementById("PrecioUnitario").value;
        var ValorIdProveedor = document.getElementById("IdProveedor").value;

        if (ValorImagenInsumo === "" || ValorNombreInsumo === "" || ValorCantidadInsumo === "" || ValorUsosDisponibles === "" || ValorCategoria === "" || ValorPrecioUnitario === "" || ValorIdProveedor === "") {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: '¡Todos los campos de insumos deben estar llenos!',
            });
            return false;
        }

        return true;
    }

    function obtenerColumna(indice) {
        var columnas = document.querySelectorAll("#tablaInsumosBody tr td:nth-child(" + (indice + 1) + ")");
        var valores = [];
        columnas.forEach(function (columna) {
            if (indice === 3) {
                valores.push(parseInt(columna.innerText.trim()));
            } else if (indice === 4) {
                valores.push(parseFloat(columna.innerText.trim()));
            }
            else if (indice === 5) {
                valores.push(parseFloat(columna.innerText.trim()));
            }
            else if (indice === 6) {
                valores.push(parseFloat(columna.innerText.trim()));
            }
            else {
                valores.push(columna.innerText.trim());
            }
        });
        return valores;
    }
});
