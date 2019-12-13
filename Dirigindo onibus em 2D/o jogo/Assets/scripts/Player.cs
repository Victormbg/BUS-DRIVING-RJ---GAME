using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public int point;
	public float aceleracao;
	float _aceleracao;
	public float move;
    bool isStopping;
    bool notAcellerating;
	bool FREIA;

	bool ligado = false;

    Rigidbody2D rigidBody2D; // Fisica 2D - Corpo Rigido

	public AudioClip ligando;
	public AudioClip desligando;
	public AudioClip acelerando;
	public AudioClip re;
	public AudioClip freiando;

	AudioSource audioSource;
	
	void Start()
	{
		rigidBody2D = GetComponent<Rigidbody2D> ();
		audioSource = GetComponent<AudioSource> ();
	}

	void Update () 
	{
		//ligar e desligar
		
		if (Input.GetKeyDown(KeyCode.L)) 
		{
			if(!ligado)
			{
				audioSource.PlayOneShot(ligando);
				Debug.Log("tocando som ligando");
			}
			else
			{
				audioSource.PlayOneShot(desligando);
				Debug.Log("tocando som DESligando");
			}

			ligado = !ligado;

			notAcellerating = true;
		}

		//desaceleracao

		if(notAcellerating)
		{
			//Debug.Log("desacelerando");
			
			//_aceleracao *= 0.99f;
			//rigidBody2D.velocity *= 0.99f;
			
			if(FREIA)
			{
				//Debug.Log("freiando");
				_aceleracao *= 0.97f;
				rigidBody2D.velocity *= 0.97f;
			}
			else
			{
				//Debug.Log("largando");
				_aceleracao *= 0.99f;
				rigidBody2D.velocity *= 0.99f;
			}
			
			
			if (_aceleracao < 0.1f && _aceleracao > -0.1f )
				_aceleracao = 0;
			
			if (rigidBody2D.velocity.x < 0.1f && rigidBody2D.velocity.x > -0.1f)
			{
				rigidBody2D.velocity = new Vector2(0, rigidBody2D.velocity.y);
				if(ligado)
				{
					//audioSource.Stop();
				}
			}
			
		}
		
		rigidBody2D.AddForce(new Vector2(_aceleracao, 0), ForceMode2D.Force);
		
		if(rigidBody2D.velocity.x > 25 || rigidBody2D.velocity.x < -15)
		{
			_aceleracao = 0;
		}

		//daqui pra frente so ligado

		if (!ligado)
		{
			return;
		}

		//moveX = Input.GetAxis ("Horizontal");

        //rigidBody2D.velocity = new Vector2 (moveX, 0);
			
		//if (Input.GetKeyDown (KeyCode.W)) 
		//{
		//	rigidBody2D.AddForce(new Vector2(0, moveX), ForceMode2D.Force);
		//}
	
		//Debug.Log ("PONTOS " + point);

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, move * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -move * Time.deltaTime, 0);
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
			_aceleracao = -aceleracao;
            notAcellerating = false;

			//audioSource.PlayOneShot(re);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
			notAcellerating = false;
			_aceleracao = aceleracao;
			
			//audioSource.PlayOneShot(acelerando);
        }

		//largando o pedal
		if (Input.GetKeyUp(KeyCode.A) 
		    || Input.GetKeyUp(KeyCode.LeftArrow)
		    || Input.GetKeyUp(KeyCode.D) 
		    || Input.GetKeyUp(KeyCode.RightArrow) 
		    || Input.GetKeyUp(KeyCode.Space))
        {
			notAcellerating = true;
        }

		//freiada
		if (Input.GetKey(KeyCode.Space))
		{			
			//audioSource.PlayOneShot(freiando);
			
			notAcellerating = true;
			
			FREIA = true;
			
			//if (rigidBody2D.velocity.x != 0)
			//  _aceleracao = -(_aceleracao * 5);
			//else
			//  _aceleracao = 0;   
		}

		//SONS

		if(!notAcellerating)
		{
			if(!audioSource.isPlaying)
			audioSource.PlayOneShot(acelerando);
		}
		if(FREIA)
		{
			if(!audioSource.isPlaying)
				audioSource.PlayOneShot(freiando);
			//StartCoroutine(TocarSomFreio());
		}       
    }

	IEnumerator TocarSomFreio()
	{
		audioSource.Stop();
		if(!audioSource.isPlaying)
			audioSource.PlayOneShot(freiando);
		yield return new WaitForSeconds(3);
	}

  }