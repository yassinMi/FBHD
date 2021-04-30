#v2.0.0 
#user requests now are prefixed with the 'mi_request: ' to defirentiate between reqests and python errors, e.g: "mi_request: https://fb.com/ehezl"
import sys
import http.server
import socketserver

PORT = 8000


class myHandler (http.server.BaseHTTPRequestHandler):
    def do_POST(something):
        #print(type(something))
        
        something.send_response_only(200,"success".encode())
        something.end_headers()
        print("mi_request: "+something.rfile.read1(1000).decode() )
        sys.stdout.flush()
        #something.wfile.write("url transfered successfully".encode())
        #print (something.wfile )

       

Handler = myHandler
try:
    httpd = socketserver.TCPServer(("", PORT), Handler)
except OSError as e:
    print("mi_error: couldn't start socketserver",e.strerror )
    sys.stdout.flush()
    shouldKill = input("should kill? (y/n)")
    if shouldKill in ('y', 'ye', 'yes'):
        pass
        print("killing.." )
        sys.stdout.flush()
    if shouldKill in ('n', 'no', 'nop', 'nope'):
            exit()

else:
    print("serving at port", PORT)
    sys.stdout.flush()
    httpd.serve_forever()
