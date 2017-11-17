﻿Blockly.Blocks['icon_change_color_red'] = {
  init: function() {
    this.appendDummyInput()
        .appendField('change color to red');
    this.setColour(160);
    this.setTooltip('Change the color of the icon');
    this.setNextStatement(true);
    this.setPreviousStatement(true);  
  }
};

Blockly.JavaScript['icon_change_color_red'] = function (block) {
    // String or array length.
    var code = "$('#targetElement').addClass('red');";
    return [code, Blockly.JavaScript.ORDER_MEMBER];
};