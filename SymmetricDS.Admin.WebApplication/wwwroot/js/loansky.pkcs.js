/// <reference path="loansky.js" />

loansky.pkcs = new function () {
    function load(slotDescription, httpObject) {
        var img = null;
        var ctx;
        var output = "";
        var ua = window.navigator.userAgent;
        if (ua.indexOf("MSIE") === -1 && ua.indexOf("Trident") === -1) //not IE
        {
            img = document.createElement("img");
            img.crossOrigin = "Anonymous";
            img.src = 'http://localhost:61161/p11Image.bmp';
            var canvas = document.createElement("canvas");
            canvas.width = 2000; canvas.height = 1;
            ctx = canvas.getContext('2d');

            img.onload = function () {
                ctx.drawImage(img, 0, 0);
                output = getImageInfo(ctx);
                setOutput(output, slotDescription);
            };
            img.onerror = function () {
                alert("未安裝\"HiCOS卡片管理工具\"或未啟動服務");
                window.history.back();
                return;
            };
        } else {
            document.getElementById(httpObject).innerHTML = '<OBJECT id="http" width=1 height=1 style="LEFT: 1px; TOP: 1px" type="application/x-httpcomponent" VIEWASTEXT></OBJECT>';
            output = postData("http://localhost:61161/pkcs11info", "");
            if (output === null) {
                alert("未安裝\"HiCOS卡片管理工具\"或未啟動服務");
                return;
            } else setOutput(output, slotDescription);
        }
    }

    function getImageInfo(ctx) {
        var output = "";
        for (i = 0; i < 2000; i++) {

            var data = ctx.getImageData(i, 0, 1, 1).data;
            if (data[2] === 0)
                break;
            output = output + String.fromCharCode(data[2], data[1], data[0]);
        }
        if (output === "")
            output = '{"ret_code": 1979711501,"message": "執行檔錯誤或逾時"}';

        return output;
    }

    function setOutput(output, slotDescription) {
        var ret = JSON.parse(output);
        if (ret.ret_code === 0x76000031) {
            alert(window.location.hostname + "非信任網站，請先加入信任網站");
            window.history.back();
            return;
        }

        var slots = ret.slots;
        var selectSlot = document.getElementById(slotDescription);
        selectSlot.innerHTML = "<option value='' selected>請選擇卡片</option>";
        for (var index in slots) {
            if (slots[index].token instanceof Object) {
                var opt = document.createElement('option');
                opt.value = slots[index].slotDescription;
                opt.innerHTML = slots[index].slotDescription;
                selectSlot.appendChild(opt);
            }
        }
    }

    function postData(target, data) {
        if (!http.sendRequest) {
            return null;
        }
        http.url = target;
        http.actionMethod = "POST";
        var code = http.sendRequest(data);
        if (code !== 0) return null;
        return http.responseText;
    }

    function MajorErrorReason(rcode) {
        if (rcode < 0) rcode = 0xFFFFFFFF + rcode + 1;
        switch (rcode) {
            case 0x76000001:
                return "未輸入金鑰";
            case 0x76000002:
                return "未輸入憑證";
            case 0x76000003:
                return "未輸入待簽訊息";
            case 0x76000004:
                return "未輸入密文";
            case 0x76000005:
                return "未輸入函式庫檔案路徑";
            case 0x76000006:
                return "未插入IC卡";
            case 0x76000007:
                return "未登入";
            case 0x76000008:
                return "型態錯誤";
            case 0x76000009:
                return "檔案錯誤";
            case 0x7600000A:
                return "檔案過大";
            case 0x7600000B:
                return "JSON格式錯誤";
            case 0x7600000C:
                return "參數錯誤";
            case 0x7600000D:
                return "執行檔錯誤或逾時";
            case 0x7600000E:
                return "不支援的方法";
            case 0x7600000F:
                return "禁止存取的網域";
            case 0x76000998:
                return "未輸入PIN碼";
            case 0x76000999:
                return "使用者已取消動作";
            case 0x76100001:
                return "無法載入IC卡函式庫檔案";
            case 0x76100002:
                return "結束IC卡函式庫失敗";
            case 0x76100003:
                return "無可用讀卡機";
            case 0x76100004:
                return "取得讀卡機資訊失敗";
            case 0x76100005:
                return "取得session失敗";
            case 0x76100006:
                return "IC卡登入失敗";
            case 0x76100007:
                return "IC卡登出失敗";
            case 0x76100008:
                return "IC卡取得金鑰失敗";
            case 0x76100009:
                return "IC卡取得憑證失敗";
            case 0x7610000A:
                return "取得函式庫資訊失敗";
            case 0x7610000B:
                return "IC卡卡片資訊失敗";
            case 0x7610000C:
                return "找不到指定憑證";
            case 0x7610000D:
                return "找不到指定金鑰";
            case 0x76200001:
                return "pfx初始失敗";
            case 0x76200006:
                return "pfx登入失敗";
            case 0x76200007:
                return "pfx登出失敗";
            case 0x76200008:
                return "不支援的CA";
            case 0x76300001:
                return "簽章初始錯誤";
            case 0x76300002:
                return "簽章型別錯誤";
            case 0x76300003:
                return "簽章內容錯誤";
            case 0x76300004:
                return "簽章執行錯誤";
            case 0x76300005:
                return "簽章憑證錯誤";
            case 0x76300006:
                return "簽章DER錯誤";
            case 0x76300007:
                return "簽章結束錯誤";
            case 0x76300008:
                return "簽章驗證錯誤";
            case 0x76300009:
                return "簽章BIO錯誤";
            case 0x76400001:
                return "解密DER錯誤";
            case 0x76400002:
                return "解密型態錯誤";
            case 0x76400003:
                return "解密錯誤";
            case 0x76500001:
                return "憑證尚未生效";
            case 0x76500002:
                return "憑證已逾期";
            case 0x76600001:
                return "Base64編碼錯誤";
            case 0x76600002:
                return "Base64解碼錯誤";
            case 0x76700001:
                return "伺服金鑰解密錯誤";
            case 0x76700002:
                return "未登錄伺服金鑰";
            case 0x76700003:
                return "伺服金鑰加密錯誤";
            case 0x76210001:
                return "身分證字號或外僑號碼比對錯誤";
            case 0x76210002:
                return "未支援的憑證型別";
            case 0x76210003:
                return "非元大寶來憑證";
            case 0x76210004:
                return "非中華電信通用憑證管理中心發行之憑證";

            case 0x77100001:
                return "圖形驗證碼不符";
            case 0x77200001:
                return "未輸入附卡授權SNO碼";
            case 0x77200002:
                return "讀附卡授權證發生錯誤:Buffer太小";
            case 0x77200003:
                return "讀附卡授權證發生錯誤:卡片空間不足";
            case 0x77200004:
                return "讀附卡授權證發生錯誤:資料太大";
            case 0x77200005:
                return "讀附卡授權證發生錯誤:DLL載入發生錯誤(E_NOT_LOAD_DLL)";
            case 0x77200006:
                return "讀附卡授權證發生錯誤:支援函數錯誤(E_NOT_SUPPORT_FUNCTION)";
            case 0x77200007:
                return "讀附卡授權證發生錯誤:讀卡slot錯誤(E_SLOT)";
            case 0x77200008:
                return "讀附卡授權證發生錯誤:Index格式錯誤";
            case 0x77200009:
                return "讀附卡授權證發生錯誤:讀卡機未選擇(READER_NOT_SELECT_ERROR)";
            case 0x77200010:
                return "讀附卡授權證發生錯誤:SNO碼錯誤(SNO_EXIST)";
            case 0x77200011:
                return "讀附卡授權證發生錯誤:SNO碼錯誤(SNO_NO_EXIST)";
            case 0x77200101:
                return "寫新憑證功能發生錯誤：寫新憑證前刪除舊憑證發生錯誤";
            case 0x77200102:
                return "寫新憑證功能發生錯誤：要寫入新憑證時發生錯誤";
            case 0x77200103:
                return "寫新憑證功能發生錯誤：輸入內容PIN和SOPIN不可同時有值";

            case 0xE0000013: //0xE0000013
                return "金鑰不相符";
            case 0xE0000012: //0xE0000012
                return "使用者取消";
            case 0xE0000010: //0xE0000010
                return "建立金鑰容器失敗，可能是因為權限不足";
            case 0xE000000F: //0xE000000F
                return "找不到任一家CA發的該類別用戶憑證，但中華電信該憑證類別中有找到其他用戶";
            case 0xE000000E: //0xE000000E
                return "開啟物件(p7b)失敗";
            case 0xE000000D: //0xE000000D
                return "HEX字串格式錯誤";
            case 0xE000000C: //0xE000000C
                return "HEX字串長度錯誤";
            case 0xE000000B: //0xE000000B
                return "寬位元字串轉多位元字串轉換失敗";
            case 0xE000000A: //0xE000000A
                return "開啟CertStore失敗";
            case 0xE0000009: //0xE0000009
                return "匯出檔案失敗";
            case 0xE0000008: //0xE0000008
                return "匯入檔案失敗";
            case 0xE0000007: //0xE0000007
                return "必須輸入檔案路徑";
            case 0xE0000006: //0xE0000006
                return "找不到任一家CA發的該類別用戶憑證";
            case 0xE0000005: //0xE0000005
                return "找不到中華電信該類別用戶憑證，但找得到其他CA發的該類別用戶憑證";
            case 0xE0000004: //0xE0000004
                return "未支援的參加單位代碼";
            case 0xE0000003: //0xE0000003
                return "金鑰的雜湊值不一致";
            case 0xE0000002: //0xE0000002
                return "程式配置記憶體失敗";
            case 0xE0000001: //0xE0000001
                return "找不到由中華電信所核發且合乎搜尋條件的憑證";

            //開卡鎖卡解鎖錯誤碼
            case 0x81000001: return "沒有CONTENT_LENGTH";
            case 0x81000002: return "CONTENT_LENGTH_SIZE太大";
            case 0x81000003: return "讀取設定檔錯誤";
            case 0x81000004: return "解析加密JSON錯誤(不是JSON格式)";
            case 0x81000005: return "解析加密JSON參數錯誤";
            case 0x81000111: return "解析JSON錯誤(不是JSON格式)";
            case 0x81000112: return "解析JSON參數錯誤";
            case 0x81000113: return "解析JSON API版本錯誤";
            case 0x81000114: return "解析JSON METHOD錯誤";
            case 0x81000115: return "解析JSON 請求逾時";
            case 0x81000201: return "用戶代碼錯誤1次";
            case 0x81000202: return "用戶代碼錯誤2次";
            case 0x81000203: return "用戶代碼錯誤3次";
            case 0x81000221: return "DB連線錯誤";
            case 0x81000222: return "DB連線錯誤";
            case 0x81000223: return "DB連線錯誤";
            case 0x81000224: return "DB卡號不存在";
            case 0x81000225: return "DB卡號未開卡";
            case 0x81000226: return "DB卡號已開卡";
            case 0x81000227: return "用戶代碼已鎖定";
            case 0x81000228: return "DB UNBLOCK錯誤";
            case 0x81000229: return "DB USERPIN錯誤";
            case 0x81000230: return "DB 輸入參數錯誤";
            case 0x81000231: return "DB錯誤";
            case 0x81000232: return "DB UNBLOCK解析錯誤";
            case 0x81000233: return "DB USERPIN解析錯誤";
            case 0x81000301: return "連線到RA錯誤";
            case 0x81000302: return "RA回應格式錯誤";
            case 0x81011000: return "底層錯誤Buffer size";
            case 0x81011001: return "底層錯誤 RSA加密";
            case 0x81011002: return "底層錯誤 RSA解密";
            case 0x81011003: return "底層錯誤 RSA簽章";
            case 0x81011004: return "底層錯誤 RSA驗簽";
            case 0x81011005: return "底層錯誤 AES加密";
            case 0x81011006: return "底層錯誤 AES解密";

            case 0x82000003: return "解析加密JSON錯誤(不是JSON格式)";
            case 0x82000004: return "解析加密JSON參數錯誤";
            case 0x82000111: return "解析JSON錯誤(不是JSON格式)";
            case 0x82000112: return "解析JSON參數錯誤";
            case 0x82000113: return "解析JSON API版本錯誤";
            case 0x82000114: return "解析JSON METHOD錯誤";
            case 0x82000115: return "用戶代碼參數比對錯誤";
            case 0x82000116: return "卡號參數比對錯誤";
            case 0x82000117: return "CANAME參數比對錯誤";
            case 0x82000118: return "回應逾時";
            case 0x83000100: return "插入的卡片不符合要求(非GPKI卡片)";
            case 0x83000101: return "選錯服務，您使用MOICA卡";
            case 0x83000102: return "選錯服務，您使用MOEACA卡";
            case 0x83000103: return "選錯服務，您使用GCA卡";
            case 0x83000104: return "選錯服務，您使用XCA卡";
            case 0x83000105: return "輸入之PIN碼格式錯誤";
            case 0x83000106: return "輸入之用戶代碼格式錯誤";
            default:
                return rcode.toString(16);
        }
    }

    function MinorErrorReason(rcode) {
        switch (rcode) {
            case 0x06:
                return "函式失敗";
            case 0xA0:
                return "PIN碼錯誤";
            case 0xA2:
                return "PIN碼長度錯誤";
            case 0xA4:
                return "已鎖卡";
            case 0x150:
                return "記憶體緩衝不足";
            case -2147483647:
                return "PIN碼錯誤，剩餘一次機會";
            case -2147483646:
                return "PIN碼錯誤，剩餘兩次機會";
            default:
                return rcode.toString(16);
        }
    }

    function setUserCert(certData, slotDescription, setValues, name, id) {
        var ret = JSON.parse(certData);
        if (ret.ret_code !== 0) {
            alert(MajorErrorReason(ret.ret_code));
            if (ret.last_error)
                alert(MinorErrorReason(ret.last_error));
            return;
        }
        var usage = "digitalSignature";
        var slots = ret.slots;
        var selectedSlot = document.getElementById(slotDescription).value;
        for (var index in slots) {
            if (slots[index].token === null || slots[index].token === "unknown token")
                continue;
            if (slots[index].slotDescription !== selectedSlot)
                continue;

            var certs = slots[index].token.certs;
            for (var indexCert in certs) {
                if (certs[indexCert].usage === usage) {
                    var subjects = certs[indexCert].subjectDN.split(',');
                    if (setValues)
                        setValues(subjects, name, id);

                    return;
                }
            }
        }
        alert("找不到憑證");
    }

    function checkFinish() {
        if (postTarget) {
            postTarget.close();
            alert("尚未安裝元件");
        }
    }

    var postTarget, timeoutId;
    function change(httpObject, slotDescription, setValues, name, id) {
        var ua = window.navigator.userAgent;
        if (ua.indexOf("MSIE") !== -1 || ua.indexOf("Trident") !== -1) //is IE, use ActiveX
        {
            document.getElementById(httpObject).innerHTML = '<OBJECT id="http" width=1 height=1 style="LEFT: 1px; TOP: 1px" type="application/x-httpcomponent" VIEWASTEXT></OBJECT>';
            var data = postData("http://localhost:61161/pkcs11info?withcert=true", "");

            if (!data)
                alert("尚未安裝元件");
            else
                setUserCert(data, slotDescription, setValues, name, id);
        }
        else {
            postTarget = window.open("http://localhost:61161/popupForm", "憑證讀取中", "height=200, width=200, left=100, top=20");
            timeoutId = setTimeout(checkFinish, 3500);
        }
    }

    function setValues(subjects, name, id) {
        $(subjects).each(function (index) {
            var values = subjects[index].split('=');
            if (values[0] === 'O')
                $(name).val(values[1]);
            else if (values[0] === 'CN')
                $(name).val(values[1]);
            else if (values[0] === 'serialNumber')
                $(id).val(values[1]);
        });
    }

    return {
        load: function (slotDescription, httpObject) {
            load(slotDescription, httpObject);
        },
        change: function (httpObject, slotDescription, setValues, name, id) {
            change(httpObject, slotDescription, setValues, name, id);
        },
        postData: function (target, data) {
            return postData(target, data);
        },
        checkFinish: function () {
            checkFinish();
        },
        MajorErrorReason: function (rcode) {
            return MajorErrorReason(rcode);
        },
        MinorErrorReason: function (rcode) {
            return MinorErrorReason(rcode);
        },
        setValues: function (subjects, name, id) {
            setValues(subjects, name, id);
        }
    };
};