Blockly.Blocks['icon_change_color'] = {
    init: function () {
        var color = new Blockly.FieldColour('#000000');
        color.setColours(['#f00', '#0f0', '#00f', '#f0f', '#000', '#fff']).setColumns(3);
        this.appendDummyInput()
            .appendField('Change:')
            .appendField(new Blockly.FieldDropdown([
                ['house', 'House'],
                ['speech bubble', 'Talk']
            ]), 'ITEM');
        this.appendDummyInput()
            .appendField(' color to:')
            .appendField(color, 'COLOR');
        this.setColour(160);
        this.setTooltip('Change the color of the selected item');
        this.setInputsInline(true);
        this.setNextStatement(true);
        this.setPreviousStatement(true);
    }
};

Blockly.JavaScript['icon_change_color'] = function (block) {
    var code = "$('#icon" + block.getFieldValue('ITEM') + "')" +
                ".css('color', '" + block.getFieldValue('COLOR') + "');";
    return code;
};