using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ComponentRegistrationScope : LifetimeScope
{
    [SerializeField] private List<MonoBehaviour> behavioursToRegister;
    protected override void Configure(IContainerBuilder builder)
    {
        foreach (var mb in behavioursToRegister)
        {
            // MonoBehaviour 인스턴스의 런타임 타입을 가져옴
            Type type = mb.GetType();

            // 디버깅을 위한 등록 정보 로그 출력
            Debug.Log("Registering Component: " + mb.gameObject.name);
            Debug.Log("Type: " + type.ToString());

            // 런타임 타입을 사용하여 generic RegisterComponent<T> 메서드를 생성
            MethodInfo method = typeof(ContainerBuilderUnityExtensions)
                                .GetMethod("RegisterComponent", BindingFlags.Static | BindingFlags.Public)
                                .MakeGenericMethod(type);

            // 컨테이너 빌더와 컴포넌트 인스턴스를 전달하여 메서드 실행
            method.Invoke(null, new object[] { builder, mb }); 
        }
    }
}
