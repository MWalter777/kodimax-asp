$(function (){

	$("#DELEY_DESCUENTO").change(function () {
		if (this.checked) {
			$("#PORCENTAJE").val("").prop('required', true).prop('disabled', false);
			$("#DESCUENTO").val("").prop('required', false).prop('disabled', true);
			$("#FECHA_INICIO").val("").prop('required', false).prop('disabled', true);
			$("#FECHA_FIN").val("").prop('required', false).prop('disabled', true);
		} else {
			$("#PORCENTAJE").val("").prop('required', false).prop('disabled', true);
			$("#DESCUENTO").val("").prop('required', true).prop('disabled', false);
			$("#FECHA_INICIO").val("").prop('required', true).prop('disabled', false);
			$("#FECHA_FIN").val("").prop('required', true).prop('disabled', false);
		}
	});
	
});