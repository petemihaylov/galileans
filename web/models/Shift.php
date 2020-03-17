<?php

class Shift{

    private $ID;
    private $ShiftDate;
    private $StartTime;
    private $EndTime;
    private $ShiftType;


    function __construct($id, $shiftDate, $startTime, $endTime, $shiftType){
        $this->ID = $id;
        $this->ShiftDate = $shiftDate;
        $this->StartTime = $startTime;
        $this->EndTime = $endTime;
        $this->ShiftType = $shiftType;
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

    function get_ShiftType(){
        return $this->ShiftType;
    }
    function set_ShiftDate($d){
        $this->ShiftDate = $d;
    }
}