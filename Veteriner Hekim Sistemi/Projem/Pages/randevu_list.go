package main
import(
	"net/http"
)
type MyMux struct{
}
func (p *MyMux) ServeHTTP(w http.ResponseWriter,r *http.Request){
	if r.URL.Path=="/"{
	sayhelloName(w,r)
	return
}
http.NotFound(w,r)
return
}
func sayhelloName(w http.ResponseWriter,r *http.Request){

	var frm=[]byte(`[
  {
    "Randevu_ID":  " ",
		"Hastanin_Turu":" " ,
		"Hastanin_Cinsi": " ",
		"Mikrocip_No": " " ,
		"Muayene_Nedeni":" " , 
		"Sahibinin_ismi": " " ,
 		"Sahibini_soyismi": " " ,
 		"Telefon_No" : " " ,
		"Randevu_Tarihi":
  },
  {
    "Randevu_ID":  " ",
		"Hastanin_Turu":" " ,
		"Hastanin_Cinsi": " ",
		"Mikrocip_No": " " ,
		"Muayene_Nedeni":" " , 
		"Sahibinin_ismi": " " ,
 		"Sahibini_soyismi": " " ,
 		"Telefon_No": " " ,
		"Randevu_Tarihi":
  },
  {
    "Randevu_ID":  " ",
		"Hastanin_Turu":" " ,
		"Hastanin_Cinsi": " ",
		"Mikrocip_No": " " ,
		"Muayene_Nedeni":" " , 
		"Sahibinin_ismi": " " ,
 		"Sahibini_soyismi": " " ,
 		"Telefon_No": " " ,
		"Randevu_Tarihi":
  },
  {
    "Randevu_ID":  " ",
		"Hastanin_Turu":" " ,
		"Hastanin_Cinsi": " ",
		"Mikrocip_No": " " ,
		"Muayene_Nedeni":" " , 
		"Sahibinin_ismi": " " ,
 		"Sahibini_soyismi": " " ,
 		"Telefon_No": " " ,
		"Randevu_Tarihi":
  },
  {
    "Randevu_ID":  " ",
		"Hastanin_Turu":" " ,
		"Hastanin_Cinsi": " ",
		"Mikrocip_No": " " ,
		"Muayene_Nedeni":" " , 
		"Sahibinin_ismi": " " ,
 		"Sahibini_soyismi": " " ,
 		"Telefon_No": " " ,
		"Randevu_Tarihi":
  },
  {
    "Randevu_ID":  " ",
		"Hastanin_Turu":" " ,
		"Hastanin_Cinsi": " ",
		"Mikrocip_No": " " ,
		"Muayene_Nedeni":" " , 
		"Sahibinin_ismi": " " ,
 		"Sahibini_soyismi": " " ,
 		"Telefon_No": " " ,
		"Randevu_Tarihi":
  },
]	`);

	w.Write(frm);
}
func main(){
	mux:=&MyMux{}
	http.ListenAndServe("192.168.103.86:9090",mux)
}