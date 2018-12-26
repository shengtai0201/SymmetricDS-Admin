/// <reference path="loansky.js" />
/// <reference path="loansky.pkcs.js" />

loansky.pkcs.sign = new function () {
    function getTbsPackage(tbs, pin) {
        var tbsData = {};
        tbsData["tbs"] = encodeURIComponent(tbs);
        tbsData["tbsEncoding"] = "base64";
        tbsData["hashAlgorithm"] = "SHA256";
        tbsData["withCardSN"] = false;
        tbsData["pin"] = encodeURIComponent(pin);
        tbsData["nonce"] = "";
        tbsData["func"] = "MakeSignature";
        tbsData["signatureType"] = "PKCS7";
        var json = JSON.stringify(tbsData);
        return json;
    }

    function setSignature(signature) {
        var ret = JSON.parse(signature);

        var pkcs7 = null;
        if (ret.ret_code !== 0) {
            alert(loansky.pkcs.MajorErrorReason(ret.ret_code));
            if (ret.last_error)
                alert(loansky.pkcs.MinorErrorReason(ret.last_error));
        }
        else
            pkcs7 = { Base64String: ret.signature };

        return pkcs7;
    }

    var postTarget, timeoutId;
    function makeSignature(httpObject, base64Strings, pin, slotDescription) {
        var selectedSlot = document.getElementById(slotDescription).value;
        if (pin == "" || pin == null || selectedSlot == "") {
            alert("PIN碼未填寫或讀卡機未選擇");
            return false;
        }

        var models = [];
        var ua = window.navigator.userAgent;
        if (ua.indexOf("MSIE") !== -1 || ua.indexOf("Trident") !== -1) //is IE, use ActiveX
        {
            postTarget = window.open("http://localhost:61161/waiting.gif", "Signing", "height=200, width=200, left=100, top=20");
            $(base64Strings).each(function (index) {
                var isLastElement = index === base64Strings.length - 1;

                var tbsPackage = getTbsPackage(base64Strings[index], pin);
                document.getElementById(httpObject).innerHTML = '<OBJECT id="http" width=1 height=1 style="LEFT: 1px; TOP: 1px" type="application/x-httpcomponent" VIEWASTEXT></OBJECT>';
                var data = loansky.pkcs.postData("http://localhost:61161/sign", "tbsPackage=" + tbsPackage);

                var pkcs7 = null;
                if (!data) {
                    postTarget.close();
                    postTarget = null;
                    alert("尚未安裝元件");
                } else if (isLastElement) {
                    postTarget.close();
                    postTarget = null;

                    pkcs7 = setSignature(data);
                    if (pkcs7 === null) {
                        models = null;
                        return false;
                    } else
                        models.push(pkcs7);
                } else {
                    pkcs7 = setSignature(data);
                    if (pkcs7 === null) {
                        models = null;

                        postTarget.close();
                        postTarget = null;

                        return false;
                    } else
                        models.push(pkcs7);
                }
            });
        }
        else {
            postTarget = window.open("http://localhost:61161/popupForm", "簽章中", "height=200, width=200, left=100, top=20");
            timeoutId = setTimeout(loansky.pkcs.checkFinish, 3500);
        }

        return models;
    }

    return {
        makeSignature: function (httpObject, base64Strings, pin, slotDescription) {
            return makeSignature(httpObject, base64Strings, pin, slotDescription);
        }
    };
};