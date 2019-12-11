<?php
function checkPlaca($placa) {
    $token = hash_hmac('sha1', $placa, $placa . '#8.1.0#0KnlVSWHxOih3zKXBWlo', false);
    $firebaseAuth = 'li69ee1KY52:APA91bEtwOpw_NZsSeBgdW5fmQsBf0CgDmZ0txJ5dAuyRQuW6ozSO2XpNuCYJhfOUrrbQACCIJ4dgsGQ6fqD4GJB19cE2vHqcvOJueW6xl6Vd4YgjWQBh91Xin82JvW_pBLHOw6Cvo9j';
    $firebaseToken = explode(':', $firebaseAuth);
    $fToken = (strlen($firebaseToken[0]) == 11) ? $firebaseToken[0] : $firebaseToken[1];
    $request = "<v:Envelope xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:d=\"http://www.w3.org/2001/XMLSchema\" xmlns:c=\"http://schemas.xmlsoap.org/soap/encoding/\" xmlns:v=\"http://schemas.xmlsoap.org/soap/envelope/\"> <v:Header> <b>motorola</b> <c>ANDROID</c> <d>8.1.0</d> <e>4.7.4</e> <f>10.0.0.1</f> <g>" . $token . "</g> <h>0</h> <i>0</i> <k /> <l>" . date("Y-m-d H:i:s") . "</l> <m>8797e74f0d6eb7b1ff3dc114d4aa12d3</m> <n>" . $fToken . "</n></v:Header> <v:Body> <n0:getStatus xmlns:n0=\"http://soap.ws.placa.service.sinesp.serpro.gov.br/\"> <a>" . $placa . "</a> </n0:getStatus> </v:Body> </v:Envelope>";
    $header = array(
        "Content-type: application/x-www-form-urlencoded; charset=UTF-8",
        "Accept: text/plain, */*; q=0.01",
        "Cache-Control: no-cache",
        "Pragma: no-cache",
        "Content-length: " . strlen($request),
        "User-Agent: SinespCidadao / 3.0.2.1 CFNetwork / 758.2.8 Darwin / 15.0.0",
        "Authorization: Token " . $fToken . ":" . end($firebaseToken)
    );
    $soap_do = curl_init();
    curl_setopt($soap_do, CURLOPT_URL, "https://cidadao.sinesp.gov.br/sinesp-cidadao/mobile/consultar-placa/v5");
    curl_setopt($soap_do, CURLOPT_CONNECTTIMEOUT, 10);
    curl_setopt($soap_do, CURLOPT_TIMEOUT, 10);
    curl_setopt($soap_do, CURLOPT_RETURNTRANSFER, true);
    curl_setopt($soap_do, CURLOPT_SSL_VERIFYPEER, false);
    curl_setopt($soap_do, CURLOPT_SSL_VERIFYHOST, false);
    curl_setopt($soap_do, CURLOPT_POST, true);
    curl_setopt($soap_do, CURLOPT_POSTFIELDS, $request);
    curl_setopt($soap_do, CURLOPT_HTTPHEADER, $header);
    $res = curl_exec($soap_do);
//    print_r($res);die;
    return $res;
}
$placa = 'HRP1786';
//    HRP1786
//    PPL5D86
//    NDQ8878
//    MPJ7513
//    HEU7622
//    MSZ3883
//    PPJ3H87
//    ODH0331

$consultaPlaca = checkPlaca($placa);
$placaSinesp = json_encode($consultaPlaca);
$response = str_ireplace(['soap:', 'ns2:'], '', $consultaPlaca);
$results = (array) simplexml_load_string($response)->Body->getStatusResponse->return;
$consulta = json_decode(json_encode($results));
//var_dump($consulta);

$carro = explode('/', $consulta->marca);
$marca = $carro[0];
$modelo = $carro[1];
