Blockly.Blocks['icon_change_color_red'] = {
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
    var timer = 500 * Timer.count;
    Timer.count++;
    var code = "setTimeout(function(){$('#targetElement').css('color', 'red');}, " + timer + ");";
    return [code, Blockly.JavaScript.ORDER_MEMBER];
};


Blockly.Blocks['icon_change_color_green'] = {
    init: function () {
        this.appendDummyInput()
            .appendField('change color to green');
        this.setColour(160);
        this.setTooltip('Change the color of the icon');
        this.setNextStatement(true);
        this.setPreviousStatement(true);
    }
};

Blockly.JavaScript['icon_change_color_green'] = function (block) {
    var timer = 500 * Timer.count;
    Timer.count++;
    var code = "setTimeout(function(){$('#targetElement').css('color', 'green');}, " + timer + ");";
    return [code, Blockly.JavaScript.ORDER_MEMBER];
};