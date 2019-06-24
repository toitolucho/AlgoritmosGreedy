#include <iostream>
#include <algorithm>
#include <string>
#include <vector>
#include <sstream>
using namespace std;
class Actividad{
public: 
	string nombre;
	int tiempoInicio;
	int tiempoFin;
	
	Actividad()
	{
		
	}
	//funcion que convierte todo el objeto a cadena
	string toString()
	{
		return  nombre + "  -> " + static_cast<ostringstream*>( &(ostringstream() <<tiempoInicio <<"-" << tiempoFin) )->str(); ;
	}
};


//funcion que compara dos Actividades por el criterio de TiempoFin
bool compararActividades(const Actividad* a, const Actividad* b)
{
	return (a->tiempoFin < b->tiempoFin);
}


int main(int argc, char *argv[]) {
	//declaramos el vector de actividades por medio de una lista
	vector<Actividad*> lista;
	int n, i,j, ti,tf;
	string nom;
	//lectura de la cantidad de actividades a evaluar
	cin>>n;
	for(i = 0; i<n; i++)
	{
		//creamos una actividad y asignamos sus datos a su atributos
		Actividad* act;
		act = new Actividad();
		cin>>nom>>ti>>tf;		
		act->nombre = nom;
		act->tiempoInicio = ti;
		act->tiempoFin = tf;
		//agregamos el objeto creado a nuestro vector
		lista.push_back(act);
	}
	cout<<"Desornenado"<<endl;
	for(i = 0; i< n; i++)
		cout<<lista[i]->toString()<<endl;
	
	//ordenamos nuestras actividades por el criterio del tiempo final
	//recuerde que para que una lista pueda ordenar, necesita una función que permita comparar
	//dos actividades con un criterio.
	sort(lista.begin(), lista.end(), compararActividades);
	
	cout<<"Ordenado por tiempo final"<<endl;
	for(i = 0; i< n; i++)
		cout<<lista.at(i)->toString()<<endl;
	
	
	
	cout<<"Actividades que se deberian realizar : "<<endl;
	i = 0;
	cout<<lista.at(i)->toString()<<endl;
	
	
	for ( j = 1; j < n; j++)
	{
		// If this activity has start time greater than or 
		// equal to the finish time of previously selected 
		// activity, then select it 
		if (lista[j]->tiempoInicio >= lista[i]->tiempoFin)
		{
			cout<<lista.at(j)->toString()<<endl;
			i = j;
		}
	}

	return 0;
}

