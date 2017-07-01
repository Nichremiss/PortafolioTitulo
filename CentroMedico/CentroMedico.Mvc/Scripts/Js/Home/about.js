
function CargaTabla(data) {

    // dataSource
    var source =
    {
        dataType: 'json',
        dataFields: [
            { name: 'secretaria_id', type: 'string' },
            { name: 'secretaria_rut', type: 'string' },
            { name: 'secretaria_nombre', type: 'string' },
            { name: 'secretaria_apellido_paterno', type: 'string' },
            { name: 'secretaria_apellido_materno', type: 'string' },
            { name: 'secretaria_email', type: 'string' },
            { name: 'secretaria_clave', type: 'string' }
        ],
        id: 'secretaria_id',
        localdata: data 
    };

    var dataAdapter = new $.jqx.dataAdapter(source);

    //init Grid
    $("#jqxGridPrueba").jqxGrid(
        {
            sortable: true,
            source: dataAdapter,
            localization: getLocalization('es'),
            columns: [
                { text: 'RUT', datafield: 'secretaria_rut', type: 'string' },
                { text: 'NOMBRE', datafield: 'secretaria_nombre', type: 'string' },
                { text: 'APELLIDO P', datafield: 'secretaria_apellido_paterno', type: 'string' },
                { text: 'APELLIDO M', datafield: 'secretaria_apellido_materno', type: 'string' },
                { text: 'EMAIL', datafield: 'secretaria_email', type: 'string' },
            ]
        });

}