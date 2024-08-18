package main
import(
	"fmt"
	"net/http"
	"encoding/json"
)
type randevu struct {
	muayene_randevu struct {
		Randevu_ID          int       `json:"Randevu_ID"`
		Hastanin_Turu       string    `json:"Hastanin_Turu"`
		Hastanin_Cinsi      string    `json:"Hastanin_Cinsi"`
		Mikrocip_No         string    `json:"Mikrocip_No"`
		Muayene_Nedeni      string    `json:"Muayene_Nedeni"`
		Sahibinin_ismi      string    `json:"Sahibinin_ismi"`
		Sahibinin_soyismi   string    `json:"Sahibini_soyismi"`
		Telefon_No          string    `json:"Telefon_No"`
		Randevu_Tarihi      string    `json:"Randevu_Tarihi"`
	} `json:"muayene_randevu"`
}
	
type MyMux struct{
}
	var obj siparis
	var data string
	func(p *MyMux) ServeHTTP(w http.ResponseWriter,r*http.Request){
		if r.URL.Path=="/"{
			if r.Method=="POST"{
				errr:=json.NewDecoder(r.Body).Decode(&obj)
				if errr!=nil{
					fmt.Println(errr.Error());
				}
				fmt.Println(obj);
				objdata,error2:=json.Marshal(obj);
				if error2!=nil{
					fmt.Println(error2)
					return
				}
				data+=string(objdata);
			}
			if r.Method=="GET"{
				var frm=[]byte(data);
				w.Write(frm);
			}
		}
	}
	func main(){
		mux:=&MyMux{}
		http.ListenAndServe("192.168.103.86:8080",mux)
	}