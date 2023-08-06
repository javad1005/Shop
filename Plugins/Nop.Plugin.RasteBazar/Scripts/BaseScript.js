function GetJson(returnData) {
    if (returnData == "")
        return {};
    return $.parseJSON(returnData);
}
