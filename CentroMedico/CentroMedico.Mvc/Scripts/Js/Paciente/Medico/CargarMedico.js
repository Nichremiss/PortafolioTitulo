function CargaListaMedicos(data) {
    console.log(data);
    var source=
        {
            dataType: 'json',
            dataFields: [
                {name: 'medico_id', type: 'string' },
                {name: 'medico_nombre', type:'string' }
            ],
            id: 'medico_id',
            localdata: data
        };

    console.log(source);

    var dataAdapter = new $.jqx.dataAdapter(source);
    $("#ComboMedicos").jqxComboBox({ source: dataAdapter });

};
