<?php

class Shift{

    private $ID;
    private $ShiftDate;
    private $StartTime;
    private $EndTime;

    function __construct($id, $shiftDate, $startTime, $endTime){
        $this->ID = $id;
        $this->ShiftDate = $shiftDate;
        $this->StartTime = $startTime;
        $this->EndTime = $endTime;
    }

    
    function get_ID(){
        return $this->ID;
    }

    function get_ShiftDate(){
        return $this->ShiftDate;
    }
    
    function get_StartTime(){
        return $this->StartTime;
    }
    
    function get_EndTime(){
        return $this->EndTime;
    }
}