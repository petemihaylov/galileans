<?php

class Preference{

    private $ID;
    private $UserID;
    private $State;
    public $Days = array();
    public $IsWeekly = 0;
    public $IsMonthly = 0;

    function __construct($id, $userID, $state, $days, $isWeekly, $isMonthly){
        $this->ID = $id;
        $this->UserID = $userID;
        $this->State = $state;
        $this->Days = $days;
        $this->IsWeekly = $isWeekly;
        $this->IsMonthly = $isMonthly;
    }

    function get_ID(){
        return $this->ID;
    }

    function get_State(){
        return $this->State;
    }

    function get_UserID(){
        return $this->UserID;
    }


    function get_Days(){
        return $this->Days;
    }

    function get_IsWeekly(){
        return $this->IsWeekly;
    }

    function get_IsMonthly(){
        return $this->IsWeekly;
    }
}